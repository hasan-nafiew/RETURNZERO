$(document).ready(function () {

    $("#imageFile").change(function () {

        if (this.files && this.files[0]) {

            if (this.files[0].name.match(/\.(jpg|JPG|jpeg|png|gif)$/)) {

                if (!(this.files[0].size > (1 * 1024 * 1024))) {

                    var reader = new FileReader();

                    reader.onload = function (element) {
                        $("#imageFilePreview").attr('src', element.target.result);
                    };
                    reader.readAsDataURL(this.files[0]);
                } else {
                    alert("Image size larger than 1 MB");
                    $(this).val(null);
                    $("#itmageFilePreview").attr('src', null);
                }
            } else {
                alert("This is not image file");
                $(this).val(null);
                $("#imageFilePreview").attr('src', null);
            }
        } else {
            $("#imageFilePreview").attr('src', null);
        }
    });

});