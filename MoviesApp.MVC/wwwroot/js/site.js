

$(document).ready(function () {
    //getMoviesFromApi();



    const getMoviesFromApi = () => {

        $.ajax({
            type: 'Get',
            url: 'https://localhost:5001/api/Movies/GetAll',
            contentType: "application/Json",
            beforeSend: function () {
                //console.log("sending")
            },
            success: function (data) {
                console.log(data);
                let moviesTableBody = "";
                $.each(data, function (index, movie) {
                    body +=
                        `<tr name="${movie.id}">
                            <td>${movie.id}</td>
                            <td>${movie.name}</td>
                            <td>${movie.description}</td>
                            <td>${movie.artists}</td>
                            <td>${movie.subject}</td>
                        </tr>`
                });
                $("#moviesTable > tbody").html(body);
                toastr.success("Veriler api'den başarıyla çekildi");

            },
            error: (err) => {
                console.log(err);
                console.log("hata");

            }
        });
    }

    // Ajax Get : Getting the _CategoryAddPartial as Modal Form starts from here.

    //const url = '@Url.Action("Add","Category")';
    const url = '/Movie/Create';

    const placeHolderDiv = $('#modalPlaceHolder');
    $('#btnCreateMovie').click(() => {
        //get işlemi HomeController/Create isimli action'a gidip partialView'i getirir.
        $.get(url).done((data) => { //_MovieAddModalPartial view'ini data olarak döndürür.

            placeHolderDiv.html(data);
            //partialView'i html olarak placeholderDiv elementinin içine ekler.
            placeHolderDiv.find(".modal").modal('show'); //find ile "modal" class'ı içeren div'i bulur ve modal olarak açar
        });
    });


//Delete Movie


$('#btnDelete').click(() => {
    //get işlemi HomeController/Create isimli action'a gidip partialView'i getirir.
    $.get(url).done((data) => { //_MovieAddModalPartial view'ini data olarak döndürür.

        placeHolderDiv.html(data);
        //partialView'i html olarak placeholderDiv elementinin içine ekler.
        placeHolderDiv.find(".modal").modal('show'); //find ile "modal" class'ı içeren div'i bulur ve modal olarak açar
    });
});


$(document).on('click', '#btnDelete', function () {
    const rowId = $(this).attr('data-id');
    const rowToDelete = $(`[id="${rowId}"]`);
    const rowToDeleteName = rowToDelete.find('td:eq(1)').text();
    console.log(rowToDeleteName);
    console.log(rowId);
    Swal.fire({
        title: 'Delete Movie',
        text: `${rowToDeleteName} adlı filmi silmek istediğinize emin misiniz?`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Kategoriyi Sil',
        cancelButtonText: 'Vazgeç'
    }).then((result) => {
        if (result.isConfirmed) {
            console.log("success");
            $.ajax({
                type: 'delete',
                //dataType: 'json',
                data: { movieToDeleteId: rowId },
                //url: '@Url.Action("Delete","Movie")',
                url: "/Movie/Delete",
                success: function (data) { //data : 
                    /*const categoryDto = jQuery.parseJSON(data);*/
                    console.log(data);

                    console.log("successFiree");
                    Swal.fire(
                        'Başarılı!',
                        `${rowToDeleteName} adlı film başarıyla silindi.`,
                        'success'
                    );
                    toastr.info(`${rowToDeleteName} adlı kategori başarıyla silindi.`, "Silindi");
                    rowToDelete.fadeOut(1000);

                },
                error: (err) => {
                    toastr.warning("Hata", err);
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: `${rowToDeleteName}`,
                    });
                },
            });

        }
    });
});

//Delete Movie


//Create Movie
placeHolderDiv.on('click', '#btnSave', (e) => {
    e.preventDefault();
    const form = $('#form-movie-create');
    const actionUrl = "/Movie/Create";
    const serialized = form.serialize();
    console.log("serialized :");
    console.log(serialized);
    console.log("serializedArray :");
    var formDataArray = form.serializeArray();
    console.log(formDataArray);
    //for (var i = 0; i < formDataArray.length; i++) {
    //    console.log(formDataArray[i].name + " : " + formDataArray[i].value);
    //}



    $.post(actionUrl, serialized).done((data) => {

        const newFormBody = $('.modal-body', data);
        placeHolderDiv.find('.modal-body').replaceWith(newFormBody);

        const isFormValid = newFormBody.find('[name="IsValid"]').val() === 'True';
        if (isFormValid) {
            placeHolderDiv.find('.modal').modal('hide');
            var createdMoviesName = formDataArray[1].value;
            toastr.success(`${createdMoviesName} successfully created`, 'Başarılı İşlem!');
        }
        else {
            $('#validationSummary > ul > li').each(function () {
                let text = $(this).text();
                toastr.warning(text);
            });
        }
    }).fail((err) => {

        console.log("post error:");
        console.log(err.responseText);
    })
});
    // Ajax GET : Getting the _CategoryAddPartial as Modal Form ENDS here.

                                    //Create Movie
});
