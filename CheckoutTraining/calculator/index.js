"use strict";

class Calculator {
    static count = 0;
    static buttons = [
        ['7', '8', '9', '/'],
        ['4', '5', '6', '*'],
        ['1', '2', '3', '+'],
        ['0', '.', '=', '-']
    ]

    constructor() {
        this.calculatorInstanceNumber = Calculator.count;
        this.calculateString = "";
        this.renderCalculator();
        ++Calculator.count;
    }
    renderCalculator() {
        this.renderContainerDiv();
        this.renderInputField();
        this.renderButtons();
    }
    renderContainerDiv() {
        let parentElement = document.getElementById('app-root');
        let childElement = document.createElement('div');
        parentElement.appendChild(childElement);

        // assign id
        let att = document.createAttribute("id");
        att.value = `calculator-container-${Calculator.count}`;
        childElement.setAttributeNode(att);

        // assign class
        att = document.createAttribute("class");
        att.value = 'calculator-container';
        childElement.setAttributeNode(att);
    }
    renderInputField() {
        let parentElement = document.getElementById(`calculator-container-${Calculator.count}`);
        let childElement = document.createElement('input');
        childElement.disabled = true;
        parentElement.appendChild(childElement);

        // assign id
        let att = document.createAttribute("id");
        att.value = `calculator-input-field-${this.calculatorInstanceNumber}`;
        childElement.setAttributeNode(att);
    }
    renderButtons() {
        let parentElement = document.getElementById(`calculator-container-${Calculator.count}`);
        let tbl = document.createElement('table');
        let tbdy = document.createElement('tbody');

        for (let row = 0; row < 4; row++) {
            let tr = document.createElement('tr');
            for (let column = 0; column < 4; column++) {
                let td = document.createElement('td');
                td.appendChild(document.createTextNode(`${Calculator.buttons[row][column]}`));

                // assign class to button
                let att = document.createAttribute("class");
                att.value = 'calculator-btn';
                td.setAttributeNode(att);

                // assign values
                att = document.createAttribute("value");
                att.value = `${Calculator.buttons[row][column]}`;
                td.setAttributeNode(att);

                // set function binding
                td.onclick = this.calculate;

                tr.appendChild(td);
            }
            tbdy.appendChild(tr);
        }
        tbl.appendChild(tbdy);
        parentElement.appendChild(tbl)
    }
    calculate(event) {
        let clickedButtonValue = event.srcElement.innerHTML;
        // let inputElement = document.getElementById(`calculator-input-field-${this.calculatorInstanceNumber}`);

        let inputElementId = event.srcElement.parentElement.parentElement.parentElement.parentElement.firstChild.id;
        let inputElement = document.getElementById(inputElementId);

        console.log(this.calculatorInstanceNumber);

        if (clickedButtonValue == "=") {
            inputElement.value = eval(inputElement.value);
            this.calculateString = "=";
        } else {
            this.calculateString = inputElement.value.concat(clickedButtonValue);
            inputElement.value = this.calculateString;
        }
    }
}

let calc1 = new Calculator();
let calc2 = new Calculator();
