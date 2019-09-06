$(document).ready(function () {
    let empListSelector = $("#manager-id-data-list");
    let managerId = $("#manager-id");

    $("#manager-id-data-btn").click(function () {
        if (empListSelector.children().length == 0) {
            $.ajax({
                type: 'GET',
                url: 'manager/' + managerId.val(),
                dataType: 'json',
                success: function (data) {
                    let empLi = document.createElement("li");
                    if (data != null) {
                        empLi.innerHTML = data["name"];
                    } else {
                        empLi.innerHTML = "no managers found with specified id";
                    }
                    empListSelector.append(empLi);
                },
                error: function (result) {
                    console.log("Error\t" + result);
                }
            });
        }
    });

    $("#manager-id-data-btn-clear").click(function () {
        empListSelector.empty();
        managerId.val('');
    });
});