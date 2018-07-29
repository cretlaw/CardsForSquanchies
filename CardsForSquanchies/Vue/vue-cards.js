new Vue({
    el: "#CardsApp",
    data: {
        cards: [],
        rowDisplay:true
    },
    created: function () {

        let vm = this;

        axios.get("http://localhost:52007/api/cards")
            .then(response => {
                this.cards = response.data.slice()
            })
    },
    methods: {
        toggleRow: function (index) {
            if (index % 3 === 0) {
                this.rowDisplay = true
            } else {
                this.rowDisplay = false
            }
            
        }
    }
})