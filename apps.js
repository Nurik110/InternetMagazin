const url = "https://localhost:44363/odata"
const vm = new Vue({
    el: '#app',
    data: {
        values: []
    },
    async mounted() {
        this.getValues();
    },
    methods: {
        async getValues() {
            await axios.get(`${url}/KazakhBests`).then((response) => {
                this.values = response.data.value;
            });
        },
        buyNow(item) {
            // const appm = new Vue({
            //     el: "#appm",
            //     data: {},
            //     mounted() {
            //       this.postRequest()
            //     },
            //     methods: {
            //       postRequest() {
            //         axios({
            //             method: 'post',
            //             url: 'https://localhost:44389/odata/KazakhBests',
            //             params: {
            //               user_key_id: 'USER_KEY_ID',
            //             },
            //             data: {
            //               title: 'new_title',
            //               body: 'new_body',
            //               userId: 'userid'
            //             },
            //             headers: {
            //               "Content-type": "application/json; charset=UTF-8"
            //             }
            //           })
            //           .then(function(response) {
            //             console.log('Ответ сервера успешно получен!');
            //             console.log(response.data);
            //           })
            //           .catch(function(error) {
            //             console.log(error);
            //           });
            //       }
            //     }
            //   })

            alert("Купить");
            console.log(item);
        },
        bNow(item) {
            alert("Подробнее");
            console.log(item);
        }
    }
});

