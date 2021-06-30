
$(function () {

    $("#formDetails").validate({
        rules:
        {
            UserName: {
                required: true,

            },

            PassWord: {
                required: true,
                minlength: 4,
                maxlength: 10
            }


        },
        messages:
        {
            UserName:
            {
                required: "Name is required",

            },
            PassWord:
            {
                required: "Password is required",
                minlength: "Password should have miminum of 4 characters",
                maxlength: "Password should have maximum of 10 charaacters"
            }
        }
    });
});

function SubmitDetails() {
    if ($("#formDetails").valid()) {
        $("#formDetails").submit();
    }
}