
var postCookies = [];
var popup = "";
var timer = null

function init(options) {
    postCookies = [];
    chrome.cookies.getAll({}, function (cookies) {
        if (!cookies || !cookies.length) {
            chrome.runtime.sendMessage({ type: "send", code: -1, info: { msg: '当前页面没有cookie' } });
            clearTimer()
            return
        }
        for (var i in cookies) {
            cookie = cookies[i];
            if (cookie.domain.indexOf(options.jiraDomain) != -1) {
                postCookies.push(cookie);
            }
        }

        if (postCookies && postCookies.length > 0) {
            $.ajax({
                type: "POST",
                url: "http://127.0.0.1:" + options.port,
                data: JSON.stringify(postCookies),
                contentType: "application/json;charset=utf-8",
                crossDomain: true,
                xhrFields: {
                    withCredentials: true
                },
                error: function (xhr, status, error) {
                    chrome.runtime.sendMessage({ type: "send", isSuccess: false, info: error });
                    clearTimer()
                },
                success: function (result, status, xhr) {
                    chrome.runtime.sendMessage({ type: "send", isSuccess: true, info: result });
                }
            });
        }
        else {
            chrome.runtime.sendMessage({ type: "send", isSuccess: false, info: { msg: options.jiraDomain + '：无cookie信息' } });
            clearTimer()
            return
        }
    });
}

function clearTimer() {
    timer && clearInterval(timer)
    timer = null
}

function start(options) {
    chrome.tabs.query({ highlighted: true }, function (tabs) {
        if (tabs) {
            domain = options.rootSite
            clearTimer()
            if (options.times === '一次') {
                init(options)
            } else {
                timer = setInterval(function () {
                    init(options);
                }, options.intervalSecond * 1000)
            }
        }
    })
}