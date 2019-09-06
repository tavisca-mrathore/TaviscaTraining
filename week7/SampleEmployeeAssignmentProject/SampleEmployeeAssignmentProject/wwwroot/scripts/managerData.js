$(document).ready(function () {
    let empListSelector = $("#manager-data-list");

    $("#manager-data-btn").click(function () {
        if (empListSelector.children().length == 0) {
            $.ajax({
                type: 'GET',
                url: 'manager/',
                dataType: 'json',
                success: function (data) {
                    data.forEach(function (item) {
                        let empLi = document.createElement("li");
                        empLi.innerHTML = item["name"];
                        empListSelector.append(empLi);
                    });
                },
                error: function (result) {
                    console.log("Error\t" + result);
                }
            });
        }
    });

    $("#manager-data-btn-clear").click(function () {
        empListSelector.empty();
    });
});