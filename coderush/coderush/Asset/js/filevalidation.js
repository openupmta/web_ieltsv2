function fileValidation(obj) {
    //var fileInput = document.getElementById('file'+id);
    var filePath = obj.value; //lấy giá trị input theo id
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif)$/i; //các tập tin cho phép
    //Kiểm tra định dạng
    if (!allowedExtensions.exec(filePath)) {
        alert('You can only select files with .jpeg/.jpg/.png/.gif extension.');
        obj.value = '';
        return false;
    } else {
        //Image preview
        if (obj.files && obj.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                document.getElementById('imagePreview'+obj.id).innerHTML = '<img style="width:200px;" src="' + e.target.result + '"/>';
            };
            reader.readAsDataURL(obj.files[0]);
        }
    }
}
function getVideoYoutube(obj) {
    //alertify.alert(obj.value);
    var youtube = 'https://www.youtube.com/watch?v=';
    var str = obj.value;
    var ktra = str.indexOf(youtube);
    var start = str.indexOf('=')+1;
    var end = str.indexOf('&');
    if(end==-1){
        end=str.length;
    }
    var sub= str.substring(start, end);

    if(ktra== 0){
        document.getElementById('youtube-'+obj.id).innerHTML ='<iframe width="560" height="315" src="https://www.youtube.com/embed/'+sub+'" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>'
        document.getElementById('value-'+obj.id).value = sub;
    }else{
        alertify.alert('Bạn chưa nhập dúng link youtube!');
        obj.value = '';
        document.getElementById('youtube-'+obj.id).innerHTML = '<iframe width="560" height="315" src="https://www.youtube.com/embed/'+$('#value-'+obj.id).val()+'" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>';
        document.getElementById('value-'+obj.id).value = '';

    }
}