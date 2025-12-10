const saluto: string = "Hello TypeScript!";
console.log(saluto);

let ids : number[] = [1, 2, 3, 4, 5];
ids.push(6);
console.log(ids);

enum Direction1  {	
	Up = 1,
	Down,
	Left,
	Right
}

console.log(Direction1.Up ) // 1
console.log(Direction1.Down ) // 2
console.log(Direction1.Right ) // 2


class Persona {
    public nome: string;
    private eta: number;

    constructor(nome: string, eta: number) {
        this.nome = nome;
        this.eta = eta;
    }

    // Metodo pubblico
    descrivi(): string {
        return `Sono ${this.nome} e ho ${this.getEta()} anni.`;
    }

    // Metodo privato
    private getEta(): number {
        return this.eta;
    }
}
/*commento*/
const mario = new Persona("Mario", 30);
console.log(mario.descrivi());
// console.log(mario.eta); // Errore: 'eta' è privata
class Auto {
    constructor(public marca: string, private anno: number) {}

    dettagli(): string {
        return `Questa è una ${this.marca} del ${this.anno}.`;
    }
}

const fiat = new Auto("Fiat", 2020);
console.log(fiat.dettagli());
// console.log(fiat.anno); // Errore: 'anno' è privata