function ShowDetails(id) {
    var previd = null;
    var element = document.querySelector('.active');
    var previousselectedrow;
    if (typeof (element) != 'undefined' && element != null) {
        previousselectedrow = document.querySelector('.active');
        previd = previousselectedrow.id;
        previousselectedrow.classList.remove('active');
    }

    var isalreadyvisible = $('#detailcontainer').is(':visible');
    if (isalreadyvisible) {
        previousselectedrow = document.getElementById(id);
        previousselectedrow.classList.remove("active");
    }
    var newrow = document.getElementById(id);
    newrow.classList.add("active");


    if (previd != id) {
        $.ajax({
            type: "POST",
            url: "/Main/AssignmentDetail",
            data: { Id: id },
            success: function (response) {
                $("#detailcontainer").html(response);
                $("#detailcontainer").show();
            }
        });
    } else {
        HideDetails(id);
    }
}
function ShowLoginToast(text) {
    Command: toastr["info"](text, "Login successful");
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
}

function ShowRegistrationSuccessfulToast(text) {
    Command: toastr["success"](text, "Registration successful").attr('style', 'width: 440px !important');
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
   "positionClass": "toast-top-full-width",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
}

function ShowVerificationSuccessfulToast(text) {
    Command: toastr["success"](text, "Verification successful").attr('style', 'width: 440px !important');
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-full-width",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
}

function ShowLogoutToast() {
    Command: toastr["info"]("","Logged out");
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
}


function HideDetails(id) {
    $("#detailcontainer").hide();
    var previousselectedrow = document.getElementById(id);
    previousselectedrow.classList.remove("active");
}

function SignUp() {
    $.ajax({
        type: "GET",
        url: "/Account/Registration",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $('#registrationModal').html(response);
            $('#registrationModal').modal({ 'backdrop': 'static' }, 'show');
        }
    });


}

function PostLogin() {
    document.getElementById("registrationForm").style.display = 'none';
    document.getElementById("loaderr").style.display = 'inline-block';
    var myform = $("#loginFormm").serialize();
    $.ajax({
        type: "POST",
        url: "/Account/Login",
        data: myform,
        success: function (response) {
            if (response.includes("Login successfully")) {
                $('#registrationModal').modal('hide');
                window.location.href = '/Main/Main/';
            }
            else {
                document.getElementById("registrationForm").style.display = 'inline-block';
                document.getElementById("loaderr").style.display = 'none';
                $('#registrationModal').addClass('animated shake');
                setTimeout(function () {
                    $("#registrationModal").removeClass('animated shake')
                }, 1000);
                $('#registrationModal').html(response);
                $('#registrationModal').modal('show');

            }
        }
    });
}

function PostRegister() {
    document.getElementById("registrationForm").style.display = 'none';
    document.getElementById("loaderr").style.display = 'inline-block';
    var myform = $("#registrationFormm").serialize();
    $.ajax({
        type: "POST",
        url: "/Account/Registration",
        data: myform,
        success: function (response) {
            if (response.includes("sent to")) {
                $('#registrationModal').modal('hide');
                window.location.href = '/Main/Main/';
            }
            else {
                document.getElementById("registrationForm").style.display = 'inline-block';
                document.getElementById("loaderr").style.display = 'none';
                $('#registrationModal').addClass('animated shake');
                setTimeout(function () {
                    $("#registrationModal").removeClass('animated shake')
                }, 1000);
                $('#registrationModal').html(response);
                $('#registrationModal').modal('show');

            }
        }
    });
}

function OpenMainAndModal() {
    window.location.href = '/Main/Main/';
    SignUp();

}


function SignIn() {
    $.ajax({
        type: "GET",
        url: "/Account/Login",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $('#registrationModal').html(response);
            $('#registrationModal').modal('show');
        }
    });
}

function CloseModal() {
    $('#registrationModal').hide();
}


$(document).ready(function () {
    $("#detailcontainer").hide();
});

$(window).scroll(function () {
    var elementPosition = $('.detailcontent').offset();
    if ($(window).scrollTop() > elementPosition.top) {
        $('.detailcontent').css('position', 'fixed').css('top', '0');
    } else {
        $('.detailcontent').css('position', 'relative').css('top', 0);
    }
});

