$(document).ready(function() {
    let commentsDisplaySwitcherElement = $('#comments-display-switcher');
    let isCommentsDisplayed = false;

    commentsDisplaySwitcherElement.click(function() {
        toggleComments();
    });

    function toggleComments() {
        let url = window.location.pathname;
        let id = url.substring(url.lastIndexOf('/') + 1);
        if (commentsDisplaySwitcherElement != null) {
            if (isCommentsDisplayed == true) {
                commentsDisplaySwitcherElement.html('Display comments');
                $('#comments-container').html = '';
            } else {
                commentsDisplaySwitcherElement.html('Hide comments');
                let commentsContainer = $('#comments-container');

                loadCommentWithJquery(id, commentsContainer);

            }
            isCommentsDisplayed = !isCommentsDisplayed;
        }

    }

    function loadCommentWithJquery(newsId, commentsContainer) {
        $.ajax({
                url: `/Comments/List?newsId=${newsId}`

            }).done(function(data) {
                commentsContainer.html(data);
                commentsContainer.append(
                    '<button id="special-button" type="button" class="btn btn-primary">Add</button>');


            })
            .fail(function() {
                alert("error");
            });

    }

    //function loadComments(newsId, commentsContainer) {
    //    let request = new XMLHttpRequest();
    //    request.open('GET', , true);

    //    request.onload = function () {
    //        if (request.status >= 200 && request.status < 400) {
    //            let resp = request.responseText;
    //            commentsContainer.innerHTML = resp;
    //        }
    //    }

    //    request.send();
    //}
});

