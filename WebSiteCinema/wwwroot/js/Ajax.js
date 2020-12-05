//registration
function sendRegForm(){
    let regForm = $("#regForm");
    let method = regForm.method;
    let action = regForm.action;
  
    $.ajax({
            type: method,
            url: action,
            data:{
                "login": $("#loginInput").val(),
                "email": $('#emailInput').val(),
                "phone": $('#phoneInput').val(),
                "password": $('#passwordInput2').val()
            },
        response: Boolean,
        success: function (data){
                return data
        }
        })
}