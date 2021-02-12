const vm = new Vue({
  el: '#app',
  data: {
    values: [],
    endpoint: "https://localhost:44389",
    newItem: {
      name: "",
      name_product: "",
      salary: "",
      photo: "https://static.shop.kz/upload/iblock/66a/145276_1.jpg",
      category_id: 1
    },
    
    histories: []
  },

  async mounted() {
    switch (pageType) {
      case "shop":
        this.getValues();
        break;
      case "history":
        this.getHistory();
        break;
    }

  },
  methods: {
    async getValues() {
      await axios.get(`${this.endpoint}` + url)
        .then((response) => {
          console.log(response);
          this.values = response.data.value;
        });

    },
    buyNow(item) {
      alert("Купить");
      console.log(item);

      axios.post(this.endpoint + "/odata/buyItem", {
        "productId": item.id_product,
      })
        .then((response) => {
          console.log(response);
        })
        .catch(function (error) {
          console.log(error);
        });
    },
    bNow(item) {
      alert("Подробнее");
      console.log(item);
    },
    async getHistory() {
      axios.get(this.endpoint + "/odata/Histories")
        .then((response) => {
          console.log(response);
          this.histories = response.data.value;

        })
        .catch(function (error) {
          console.log(error);
        });

    },
    async addItem() {
      axios.post(this.endpoint + "/odata/KazakhBests", {
        "name": this.newItem.name,
        "name_product": this.newItem.name_product,
        "salary": this.newItem.salary,
        "photo": this.newItem.photo,
        "category_id": this.newItem.category_id

      })
        .then((response) => {
          console.log(response);

          //Автоматом обноляются товары
          this.getValues();
          this.getHistory();
        })
        .catch(function (error) {
          console.log(error);
        });
    }
  }
});