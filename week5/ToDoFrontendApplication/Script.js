window.onload = function () {
    SetAutopopulateDataInDom();
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

function SetAutopopulateDataInDom() {
    for (let index = 0; index < AutopopulateData.length; ++index) {
        let node = document.createElement("li");
        let textnode = document.createTextNode(
            AutopopulateData[index].title
        );
        node.appendChild(textnode);
        document.getElementById("autopopulate-div-ul").appendChild(node);
    }
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
    let node = document.createElement("li");
    let nodeItem = document.createTextNode(input.value);
    node.appendChild(nodeItem);
    document.getElementById("autopopulate-div-ul").appendChild(node);
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
        // console.log("removed:\t" + previousSearchList.firstChild);
        previousSearchList.removeChild(previousSearchList.firstChild);
    }
}

function SearchItem() {
    let input = document.getElementById("input");
    let searchResults = [];

    // get results array
    for (let index = 0; index < AutopopulateData.length; ++index) {
        let foundIndex = AutopopulateData[index].title.search(input.value);
        if (foundIndex > 0) {
            searchResults.push(AutopopulateData[index]);
        }
    }

    RemoveSearchFromHTMLDOM();

    // set results to html dom
    for (let index = 0; index < 5; ++index) {
        if (searchResults.length > index) {
            let node = document.createElement("p");
            let textnode = document.createTextNode(
                searchResults[index].title
            );
            node.appendChild(textnode);
            document.getElementById("search-list").appendChild(node);
        }
    }
}