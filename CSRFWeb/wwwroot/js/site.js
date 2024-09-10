$(() => {

    $("#btnAjax").on("click", function () {
        let token = Cookies.get('X-CSRF-TOKEN');       
        $.ajax({
            url: '/card',
            type: 'post',
            data: {
                id: "101",
            },
            headers: {
                "X-CSRF-TOKEN": token
            },           
            success: function (data, status) {
                alert("Status: " + status);
            },
            error: function (data, status) {
                alert("Status: " + status);
            },
        });
        
    });

});
