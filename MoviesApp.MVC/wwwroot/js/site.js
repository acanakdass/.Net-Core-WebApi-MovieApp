

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

    //placeHolderDiv.on('click', '#btnSave', (e) => {
    //    e.preventDefault();
    //    const form = $('form-movie-create');
    //    const actionUrl = "/Movie/Create";
    //    const dataToSend = form.serialize();
    //    console.log(dataToSend);
    //    $.post(actionUrl, dataToSend).done((data) => {
    //        const movieAddPartial = jQuery.parseJSON(data);
    //        console.log(movieAddPartial);
    //        const newFormBody = $('.modal-body', movieAddPartial);
    //        placeHolderDiv.find('.modal-body').replaceWith(newFormBody);

    //        const isFormValid = newFormBody.find('[name="IsValid"]').val() === 'True';
    //        if (isFormValid) {
    //            placeHolderDiv.find('.modal').modal('hide');
    //            toastr.success('Movie successfully created', 'Başarılı İşlem!');
    //        }
    //        else {
    //            $('#validationSummary > ul > li').each(function () {
    //                let text = $(this).text();
    //                toastr.warning(text);
    //            });
    //        }
    //    }).fail((err) => {
    //        console.log(err);
    //    })
    //});
    // Ajax GET : Getting the _CategoryAddPartial as Modal Form ENDS here.










});
