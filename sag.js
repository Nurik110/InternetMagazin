const vm = new Vue({
    el: '#sag',
    data: {
        values: [],
        endpoint: "https://localhost:44389",
        newItem: {
            name: ""
        }
    },
    async mounted() {
        this.getValues();
    },
    methods: {
        async getValues() {
            await axios.get(`${this.endpoint}/odata/categories(1)/KazakhBests`).then((response) => {
                this.values = response.data.value;
            });

        },
        buyNow(item) {
            alert("Купить");
            console.log(item);
        },
        bNow(item) {
            alert("Подробнее");
            console.log(item);
        },
        async addItem() {
            axios.post(this.endpoint + "/odata/KazakhBests", {
                "name": this.newItem.name,
                "name_product": "Samsung Galaxy S20 Plus",
                "salary": "447900",
                "photo": "https://static.shop.kz/upload/iblock/66a/145276_1.jpg",
                "category_id": 1
            })
                .then((response) => {
                    console.log(response);

                    //Автоматом обноляются товары
                    this.getValues();
                })
                .catch(function (error) {
                    console.log(error);
                });
        }
    }
});