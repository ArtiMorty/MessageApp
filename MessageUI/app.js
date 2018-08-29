var app = new Vue({
    el: '#app',
    data: {
        endpoint: 'http://localhost:5000/message/send',
        message: '',
        subject: '',
        body: '',
        recipients: [null]
    },
    methods: {
        send: function () {
            this.$http.post(this.endpoint, message =
                {
                    subject: this.subject,
                    body: this.body,
                    recipients: this.recipients
                }).then(function (response) {
                    this.message = response.data;
                }, function (response) {
                    this.message = response.statusText + "\n" + response.bodyText;
                });
        },

        addRecipient: function () {
            this.recipients.push(null);
        },

        removeRecipient: function (index) {
            this.recipients.splice(index, 1);
        }
    }
});