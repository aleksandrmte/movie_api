$(document).ready(function() {

    $(".js-add-fav").each(function() {
        var isFav = $(this).attr("data-isFav").toString() === "True";
        if (isFav)
            $(this).text("Remove from favorites");
    });

    $(".js-add-fav").click(function(e) {
        e.stopPropagation();
        var isFav = $(this).attr("data-isFav").toString()==="True";
        if (isFav)
            removeFromFav(this, $(this).attr("data-favId"));
        else
            addToFav(this, $(this).attr("data-id"));
        return false;
    });

    function removeFromFav(el, favMovieId) {
        $.get('/Home/DeleteFavorite?id=' + favMovieId, function() {
            $(el).attr("data-isFav", "False");
            $(el).text("Add to favorites");
            showNotify(false);
        });
    }

    function addToFav(el, movieId) {
        $.post('/Home/AddFavorite', { movieId: movieId }, function (response) {
            $(el).attr("data-isFav", "True");
            $(el).attr("data-favId", response);
            $(el).text("Remove from favorites");
            showNotify(true);
        });
    }

    function showNotify(isAdded) {
        new Noty({
            theme: 'nest',
            timeout: 3000,
            text: isAdded? "Added": "Removed"
        }).show();
    }

});