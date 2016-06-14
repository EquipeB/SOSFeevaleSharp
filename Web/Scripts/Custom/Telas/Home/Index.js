var Home;
(function (Home) {
    var Index = (function () {
        function Index(nome) {
            var self = this;
            $(document).on('ready', function () { return self.ready.call(self); });
        }
        Index.prototype.ready = function () {
            var soma = function (a, b) {
                return a + b;
            };
            var soma1 = function (a, b) { return a + b; };
            var soma2 = function (a, b) { return a + b; };
        };
        return Index;
    }());
    Home.Index = Index;
})(Home || (Home = {}));
//# sourceMappingURL=Index.js.map