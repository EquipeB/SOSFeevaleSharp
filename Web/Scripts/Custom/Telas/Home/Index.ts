module Home {

    export class Index {
        constructor(nome) {
            var self = this;
            $(document).on('ready', () => self.ready.call(self));
        }

        ready() {
            var soma = function (a, b) {
                return a + b;
            };
            var soma1 = (a, b) => { return a + b; };
            var soma2 = (a, b) => a + b;

        }

    }
}