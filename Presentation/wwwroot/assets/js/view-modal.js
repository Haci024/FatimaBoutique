let modalBtns = document.querySelectorAll(".quick-view-modal-btn")

modalBtns.forEach(modalBtn => {
    modalBtn.addEventListener('click', function (e) {
        e.preventDefault();

        let url = modalBtn.getAttribute("href");

        fetch(url)
            .then(response => {
                if (response.ok) {
                    return response.text()
                }
                else {
                    alert("Xeta bas verdi!")
                }
            })
            .then(data => {
                $(".quick-view-modal .modal-dialog").html(data)
                $(".quick-view-modal").modal('show')
            })
    })
})