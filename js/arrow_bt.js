
$('.btn-arrow-right').click(function () {
    $('.btn-arrow-right').each(function () {
        $(this).attr('class', 'btn-arrow-right');
    });
    $('.btn-arrow').attr('class', 'btn-arrow');

    $(this).attr('class', 'btn-arrow-right btn-active');
});
$('.btn-arrow').click(function () {
    $('.btn-arrow-right').each(function () {
        $(this).attr('class', 'btn-arrow-right');
    });
    $('.btn-arrow').attr('class', 'btn-arrow');

    $(this).attr('class', 'btn-arrow btn-active');
});