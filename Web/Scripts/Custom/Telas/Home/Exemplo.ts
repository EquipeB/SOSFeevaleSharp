class Exemplo {
    public obj: any;
    public nome: string;
    public itens: Item[];

    constructor(nome: string) {
        this.nome = nome;

        this.test();
    }

    public test() {
        
    }
}

class Item {
    public Id;
    public Name;
}