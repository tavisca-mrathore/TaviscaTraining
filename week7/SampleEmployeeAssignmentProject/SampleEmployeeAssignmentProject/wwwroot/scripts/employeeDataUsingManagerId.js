$(document).ready(function () {
    let empListSelector = $("#employees-of-manager-data-list");
    let managerId = $("#employees-of-manager");

    $("#employees-of-manager-data-btn").click(function () {
        if (empListSelector.children().length == 0) {
            $.ajax({
                type: 'GET',
                url: 'manager/' + managerId.val(),
                dataType: 'json',
                success: function (data) {
                    let empLi = document.createElement("li");
                    if (data != null) {
                        empLi.innerHTML = data.empDetails.name;
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

    $("#employees-of-manager-data-btn-clear").click(function () {
        empListSelector.empty();
        managerId.val('');
    });
});