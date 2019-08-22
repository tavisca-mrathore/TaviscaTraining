window.onload = function () {
    AutoPopulateDataInTable();
    ShowRequiredSection();
}

function ShowRequiredSection(requiredId = "search-data-wrapper") {
    let sectionToBeHidden = document.getElementsByClassName('hide-section');
    for (let index = 0; index < sectionToBeHidden.length; ++index) {
        if (sectionToBeHidden[index].id === requiredId) {
            sectionToBeHidden[index].style.display = "block";
        } else {
            sectionToBeHidden[index].style.display = "none";
        }
    }
    ClearSearch();
}

function AddTableRow(dataToBeAdded, index) {
    let tableSelector = document.getElementById("autopopulate-table");

    let rowCount = tableSelector.rows.length;
    let tableRow = tableSelector.insertRow(rowCount);
    tableRow.setAttribute("id", index);

    let tableColumn1 = tableRow.insertCell(0);
    let tableColumn1TextNode = document.createTextNode(dataToBeAdded);
    tableColumn1.appendChild(tableColumn1TextNode);

    // add edit button
    let tableColumn2 = tableRow.insertCell(1);
    let tableRowEditBtn = document.createElement('button');
    tableRowEditBtn.className = "edit-btn";
    tableRowEditBtn.innerHTML = "Edit";
    tableColumn2.appendChild(tableRowEditBtn);

    // add delete button
    let tableColumn3 = tableRow.insertCell(2);
    let tableRowDeleteBtn = document.createElement('button');
    tableRowDeleteBtn.className = "delete-btn";
    tableRowDeleteBtn.innerHTML = "Delete";
    tableRowDeleteBtn.setAttribute("onclick", "DeleteRow(event);");
    tableRowDeleteBtn.setAttribute("id", "delete-" + index);
    tableColumn3.appendChild(tableRowDeleteBtn);
}

function AutoPopulateDataInTable() {
    for (let index = 0; index < AutopopulateData.length; ++index) {
        AddTableRow(AutopopulateData[index].title, index);
    }
}

function DeleteRow(event) {
    event = event || window.event;
    let target = event.target || event.srcElement;

    let e = document.getElementById("autopopulate-table");
    let first = e.firstElementChild;
    while (first) {
        first.remove();
        first = e.firstElementChild;
    }

    AutopopulateData.splice(
        parseInt(target.id.substring(7)), 1
    );
    AutoPopulateDataInTable();
}

function ShowClickedSection(event) {
    // IE does not know about the target attribute. It looks for srcElement
    // This function will get the event target in a browser-compatible way
    event = event || window.event;
    let target = event.target || event.srcElement;

    ShowRequiredSection(target.id);
}

function ClearSearch() {
    document.getElementById("input").value = "";
    RemoveSearchFromHTMLDOM();
}

function AddItem() {
    let input = document.getElementById("input");
    if (input.value == "") {
        alert("Can't enter empty entry.");
        return;
    }
    AddTableRow(input.value, AutopopulateData.length);
    AutopopulateData.push(
        {
            "title": input.value
        }
    );
    ClearSearch();
}

function RemoveSearchFromHTMLDOM() {
    const previousSearchList = document.getElementById("search-list");
    while (previousSearchList.firstChild) {
        previousSearchList.removeChild(previousSearchList.firstChild);
    }
}

function SearchItem() {
    let input = document.getElementById("input");

    RemoveSearchFromHTMLDOM();

    // get results array
    for (let index = 0; index < AutopopulateData.length; ++index) {
        let foundIndex = AutopopulateData[index].title.search(input.value);
        if (foundIndex > 0) {// set results to html dom
            let node = document.createElement("p");
            let textnode = document.createTextNode(
                AutopopulateData[index].title
            );
            node.appendChild(textnode);
            document.getElementById("search-list").appendChild(node);
        }
    }
}