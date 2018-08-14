let app = new Vue({
    el: "#CardsApp",
    data: {
        cards: [],
        isFetchingData: false
      
    },
    created: function () {
        this.isFetchingData = true
        let vm = this

        axios.get("http://localhost:52007/api/cards")
            .then(response => {
                response.data.forEach((card) => {

                    vm.cards.push({
                        frontText: card.frontText,
                        backText: card.backText,
                        isFlipped: false,
                        id:card.id
                    })

                })
                
                
                vm.isFetchingData = false
                
            })
        

    },

    methods: {
        flipCard: function (i) {
            this.cards[i].isFlipped = !this.cards[i].isFlipped
        }

    }

})