"use strict";
//  Implement a function that computes the difference between two lists.
//  The function should remove all occurrences of elements from the first list 
//  (a) that are present in the second list (b). The order of elements in the first 
//  list should be preserved in the result.
Object.defineProperty(exports, "__esModule", { value: true });
let a = [];
let b = [];
function arrayDiff(a, b) {
    return a.filter(element => !b.includes(element));
}
console.log(arrayDiff(a, b));
/////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////
///Scrivere un’arrow function che restituisce la somma di due numeri.
const sum = (x, y) => x + y;
console.log(sum(5, 10));
// Arrow function che moltiplica due numeri.
const multiply = (x, y) => x * y;
console.log(multiply(5, 10));
//Arrow function che restituisce il primo carattere di una stringa.
const firstChar = (str) => str.charAt(0);
console.log(firstChar("prova"));
//Arrow function che restituisce l’ultimo carattere di una stringa.
const lastChar = (str) => str.charAt(str.length - 1);
console.log(lastChar("prova"));
//Arrow function che converte una stringa in maiuscolo.
const toUpperCase = (str) => str.toUpperCase();
console.log(toUpperCase("provaghtw"));
//Arrow function che restituisce true se un numero è pari.
const isEven = (num) => num % 2 === 0;
console.log(isEven(4));
console.log(isEven(9));
//Arrow function che verifica se una stringa è vuota.
const isEmpty = (str) => str.length === 0;
console.log(isEmpty(""));
console.log(isEmpty("provaprova"));
//Arrow function con parametro opzionale che restituisce "Ciao, Nome" oppure "Ciao!".
const greet = (name) => name ? `Ciao, ${name}` : "Ciao!";
console.log(greet("Luca"));
console.log(greet());
//Arrow function che aggiunge un numero a un altro numero con un valore predefinito (es. 5).
const hi = 5;
const addWithDefault = (num, toAdd = hi) => num + toAdd;
console.log(addWithDefault(10));
//Usare un’arrow function con map per raddoppiare tutti i numeri di un array.
const arrayNumbers = [1, 2, 3, 4, 5, 7, 11, 34, 55, 66, 77, 12, 13, 14, 15];
const doubledNumbers = arrayNumbers.map(num => num * 2);
console.log(doubledNumbers);
//Usare un’arrow function con filter per ottenere solo i numeri pari.
const evenNumbers = arrayNumbers.filter(num => num % 2 === 0);
console.log(evenNumbers);
//Usare reduce??? e un’arrow function per sommare tutti i numeri dell’array.
const sumOfNumbers = arrayNumbers.reduce((acc, curr) => acc + curr, 0);
console.log(sumOfNumbers);
//Dato un array di stringhe, usare map con arrow function per ottenere la lunghezza di ogni stringa.
const stringArray = ["ciao", "uno", "tre", "due", "prova", "typescript", "arrow", "function"];
const stringLengths = stringArray.map(str => str.length);
console.log(stringLengths);
//Filtrare un array per ottenere solo stringhe più lunghe di 3 caratteri.
const longStrings = stringArray.filter(str => str.length > 3);
console.log(longStrings);
//Ordinare un array di numeri usando un’arrow function come comparatore.
const unsortedNumbers = [34, 2, 23, 67, 4, 89, 1, 0, -5, 100];
const sortedNumbers = unsortedNumbers.sort((a, b) => a - b);
console.log(sortedNumbers);
//Ordinare un array di oggetti { nome: string } in base al nome.
const people = [
    { nome: "Luca" },
    { nome: "Anna" },
    { nome: "Marco" },
    { nome: "Zoe" },
    { nome: "Giulia" }
];
const sortedPeople = people.sort((a, b) => a.nome.localeCompare(b.nome));
console.log(sortedPeople);
//Usare find con arrow function per trovare il primo numero maggiore di 10.
const firstGreaterThanTen = arrayNumbers.find(num => num > 10);
console.log(firstGreaterThanTen); //////////////////////dubbio
//Appiattire un array di array: [[1], [2], [3]] → [1,2,3].
const arrayOfArrays2929TEST = [[1], [2], [3], [4], [5]];
const flattenedArray = arrayOfArrays2929TEST.flat();
console.log(flattenedArray);
//Filtrare un array eliminando null e undefined.
const arrayWithNulls = [1, null, 2, undefined, 3, null, 4, "ciaone"];
const filteredArray = arrayWithNulls.filter(item => item !== null && item !== undefined);
console.log(filteredArray);
//Arrow function che restituisce un oggetto { id: number, nome: string }.
const createObject = (id, nome) => ({ id, nome });
console.log(createObject(1, "Luca"));
//Arrow function che accetta { nome, cognome } e restituisce "nome cognome".
const fullName = ({ nome, cognome }) => `${nome} ${cognome}`;
console.log(fullName({ nome: "Luca", cognome: "Rossi" }));
//Aggiungere a un oggetto un metodo scritto come arrow function.
const person = {
    nome: "Anna",
    saluta: () => "Ciao!"
};
console.log(person.saluta());
//Arrow function che accetta un oggetto generico e restituisce il valore di una proprietà passata come stringa.
const getProperty = (obj, prop) => obj[prop];
const sampleObj = { nome: "Luca", età: 30, città: "Roma" };
console.log(getProperty(sampleObj, "città"));
console.log(getProperty(sampleObj, "età"));
console.log(getProperty(sampleObj, "nome"));
//Arrow function che accetta string | number e: se numero → raddoppia; se stringa → torna stringa con !!!.
const processInput = (input) => {
    if (typeof input === "string") {
        return input + "!!!";
    }
    else {
        return input * 2;
    }
};
console.log(processInput("ciaone"));
console.log(processInput(10));
//# sourceMappingURL=index.js.map