const url = "https://localhost:44389/odata/categories(3)"
const appliancesVm = new Vue({
    el: '#appliances',
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