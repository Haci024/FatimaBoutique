
    $(document).ready(function () {
        $('#searchInput').on('input', function () {
            var query = $(this).val();


            $.ajax({
                url: '/Home/SearchBar',
                method: 'GET',
                data: { query: query },
                success: function (response) {
                    $('#searchResults').html(response);
                },
                error: function () {
                    $('#searchResults').html('<li>Arama yapılırken bir hata oluştu.</li>');
                }
            });
        });
    });

