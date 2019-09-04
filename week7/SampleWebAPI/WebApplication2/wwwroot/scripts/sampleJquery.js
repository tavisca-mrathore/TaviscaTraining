$(document).ready(function () {
    let empListSelector = $("#emp-list");

    $("#btn").click(function () {
        if (empListSelector.children().length == 0) {
            $.ajax({
                type: 'GET',
                url: 'sample/',
                dataType: 'json',
                success: function (data) {
                    data.forEach(function (item) {
                        let empLi = document.createElement("li");
                        empLi.innerHTML = item["name"];
                        empListSelector.append(empLi);
                    });
                    /*
                    $.each(data, function (index) {
                        if (data[index].hasOwnProperty("name")) {
                            empListSelector.append(`<li>${data[index]["name"]}<li>`);
                        }
                    });
                    */
                },
                error: function (result) {
                    console.log("Error\t" + result);
                }
            });
        }
    });

    $("#btnClear").click(function () {
        empListSelector.empty();
    });
});