const url = "https://localhost:44389/odata/categories(2)"
const vm = new Vue({
    el: '#lac',
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
            alert("Купить");
            console.log(item);
        },
        bNow(item) {
            alert("Подробнее");
            console.log(item);
        }

    }
});