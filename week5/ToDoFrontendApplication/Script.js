let canEditMutex, currentTextData;

window.onload = function () {
    AutoPopulateDataInTable();
    ShowRequiredSection();
    canEditMutex = true;
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
    tableRowEditBtn.setAttribute("onclick", "EditRow(event);");
    tableRowEditBtn.setAttribute("id", "edit-" + index);
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

function GetTarget(event) {
    // IE does not know about the target attribute. It looks for srcElement
    // This function will get the event target in a browser-compatible way
    event = event || window.event;
    return event.target || event.srcElement;
}

function RenderUpdatedData(updatedData) {
    // add first column
    let targetRowElement;
    if (updatedData.firstColumnElement) {
        targetRowElement = document.createElement(updatedData.firstColumnElement);
        targetRowElement.setAttribute("value", updatedData.textData);
        targetRowElement.setAttribute("class", updatedData.firstColumnElement + "-field");
    } else {
        targetRowElement = document.createTextNode(updatedData.textData);
    }

    // add first button
    let targetRowUpdateButton = document.createElement('button');
    targetRowUpdateButton.innerHTML = updatedData.secondButtonHtml;
    targetRowUpdateButton.setAttribute("onclick", updatedData.secondButtonFunction);
    targetRowUpdateButton.setAttribute(
        "id", updatedData.secondButtonHtml.toLowerCase() + "-" + updatedData.id
    );

    // add second button
    let targetRowCancelButton = document.createElement('button');
    targetRowCancelButton.innerHTML = updatedData.thirdButtonHtml;
    targetRowCancelButton.setAttribute("onclick", updatedData.thirdButtonFunction);
    targetRowCancelButton.setAttribute(
        "id", updatedData.thirdButtonHtml.toLowerCase() + "-" + updatedData.id
    );

    for (let index = 0; index < 3; ++index) {
        updatedData.targetRow.deleteCell(0);
    }

    let tableColumn1 = updatedData.targetRow.insertCell(0);
    tableColumn1.appendChild(targetRowElement);

    let tableColumn2 = updatedData.targetRow.insertCell(1);
    tableColumn2.appendChild(targetRowUpdateButton);

    let tableColumn3 = updatedData.targetRow.insertCell(2);
    tableColumn3.appendChild(targetRowCancelButton);
}

function CancelUpdateRow(event) {
    let target = GetTarget(event);

    // to get row-id after "cancel-" in button's id
    let targetRowId = target.id.substring(7);
    let targetRow = document.getElementById(targetRowId);

    RenderUpdatedData({
        "targetRow": targetRow,
        "id": targetRowId,
        "secondButtonHtml": "Edit",
        "thirdButtonHtml": "Delete",
        "secondButtonFunction": "EditRow(event);",
        "thirdButtonFunction": "DeleteRow(event);",
        "textData": currentTextData,
    });
    canEditMutex = true;
}

function UpdateRow(event) {
    let target = GetTarget(event);

    // to get row-id after "update-" in button's id
    let targetRowId = target.id.substring(7);
    let targetRow = document.getElementById(targetRowId);

    RenderUpdatedData({
        "targetRow": targetRow,
        "id": targetRowId,
        "secondButtonHtml": "Edit",
        "thirdButtonHtml": "Delete",
        "secondButtonFunction": "EditRow(event);",
        "thirdButtonFunction": "DeleteRow(event);",
        "textData": targetRow.childNodes[0].childNodes[0].value,
    });
    canEditMutex = true;
}

function EditRow(event) {
    let target = GetTarget(event);

    if (canEditMutex) {
        canEditMutex = false;
        // to get row-id after "edit-" in button's id
        let targetRowId = target.id.substring(5);
        let targetRow = document.getElementById(targetRowId);
        currentTextData = targetRow.childNodes[0].innerText;

        RenderUpdatedData({
            "targetRow": targetRow,
            "id": targetRowId,
            "firstColumnElement": "input",
            "secondButtonHtml": "Update",
            "thirdButtonHtml": "Cancel",
            "secondButtonFunction": "UpdateRow(event);",
            "thirdButtonFunction": "CancelUpdateRow(event);",
            "textData": targetRow.childNodes[0].innerText,
        });
    } else {
        alert("can't edit more than one record at a time");
    }
}

function DeleteRow(event) {
    if (canEditMutex) {
        let e = document.getElementById("autopopulate-table");
        let first = e.firstElementChild;
        while (first) {
            first.remove();
            first = e.firstElementChild;
        }

        let target = GetTarget(event);
        AutopopulateData.splice(
            parseInt(target.id.substring(7)), 1
        );
        AutoPopulateDataInTable();
    } else {
        alert("can't delete record while editing");
    }
}

function ShowClickedSection(event) {
    let target = GetTarget(event);
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

    for (let index = 0; index < AutopopulateData.length; ++index) {
        let foundIndex = AutopopulateData[index].title.toLowerCase().search(input.value.toLowerCase());
        if (foundIndex != -1) {// set results to html dom
            alert("Item already exist");
            return;
        }
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

function PopulateSearchBar(event) {
    RemoveSearchFromHTMLDOM();
    let target = GetTarget(event);
    document.getElementById("input").value =
        document.getElementById(target.id.substring(7)).childNodes[0].innerHTML;
}

function SearchItem() {
    let input = document.getElementById("input");

    RemoveSearchFromHTMLDOM();

    // get results array
    for (let index = 0; index < AutopopulateData.length; ++index) {
        let foundIndex = AutopopulateData[index].title.toLowerCase().search(input.value.toLowerCase());
        if (foundIndex != -1 && input.value != "") {// set results to html dom
            let node = document.createElement("p");
            node.setAttribute("id", "search-" + index);
            node.setAttribute("onclick", "PopulateSearchBar(event);");
            node.setAttribute("data-hidden", AutopopulateData[index].title);
            let textnode = document.createTextNode(
                AutopopulateData[index].title
            );
            node.appendChild(textnode);
            document.getElementById("search-list").appendChild(node);
        }
    }
}