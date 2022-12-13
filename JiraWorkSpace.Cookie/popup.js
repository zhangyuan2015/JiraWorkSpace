var background = chrome.extension.getBackgroundPage()
var defaultOpt = localStorage.getItem('ruleForm')
let timer = null
var isStart = false;
new Vue({
  el: '#app',
  data() {
    return {
      ruleForm: Object.assign({
        port: '2504',
        intervalSecond: 5,
        result: ""
      }, defaultOpt ? JSON.parse(defaultOpt) : {}),
    };
  },
  mounted() {
    let self = this
    chrome.runtime.onMessage.addListener(function (data) {
      if (data.type === 'send') {
        console.log(Date.now() + " - " + data.info);
        //this.result = data.info;
        //this.ruleForm.result = data.info;
        if (!data.isSuccess) {
          if (isStart) {
            isStart = false;
          }
          self.$message({
            type: 'error',
            message: data.info
          })
        } else {
          if (!isStart) {
            isStart = true;
          }
        }
      }
    })
  },
  methods: {
    submitForm(formName) {
      if (isStart) {
        background.clearTimer();
        isStart = false;
      } else {
        this.$refs[formName].validate((valid) => {
          if (valid) {
            localStorage.setItem('ruleForm', JSON.stringify(this.ruleForm))
            background.start(this.ruleForm)
            return false;
          }
        });
      }
    }
  }
})