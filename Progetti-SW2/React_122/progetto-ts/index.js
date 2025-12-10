"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const saluto = "Hello TypeScript!";
console.log(saluto);
let ids = [1, 2, 3, 4, 5];
ids.push(6);
console.log(ids);
var Direction1;
(function (Direction1) {
    Direction1[Direction1["Up"] = 1] = "Up";
    Direction1[Direction1["Down"] = 2] = "Down";
    Direction1[Direction1["Left"] = 3] = "Left";
    Direction1[Direction1["Right"] = 4] = "Right";
})(Direction1 || (Direction1 = {}));
console.log(Direction1.Up); // 1
console.log(Direction1.Down); // 2
console.log(Direction1.Right); // 2
class Persona {
    nome;
    eta;
    constructor(nome, eta) {
        this.nome = nome;
        this.eta = eta;
    }
    // Metodo pubblico
    descrivi() {
        return `Sono ${this.nome} e ho ${this.getEta()} anni.`;
    }
    // Metodo privato
    getEta() {
        return this.eta;
    }
}
const mario = new Persona("Mario", 30);
console.log(mario.descrivi());
// console.log(mario.eta); // Errore: 'eta' è privata
class Auto {
    marca;
    anno;
    constructor(marca, anno) {
        this.marca = marca;
        this.anno = anno;
    }
    dettagli() {
        return `Questa è una ${this.marca} del ${this.anno}.`;
    }
}
const fiat = new Auto("Fiat", 2020);
console.log(fiat.dettagli());
// console.log(fiat.anno); // Errore: 'anno' è privata
//# sourceMappingURL=index.js.map