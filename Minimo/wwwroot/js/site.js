// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function disablePreloader() {
    const body = document.getElementsByTagName('body')[0];
    const preloader = document.getElementById('preloader');

    body.classList.remove("no-scroll");
    preloader.classList.add('no-display');
}

function enablePreloader() {
    const body = document.getElementsByTagName('body')[0];
    const preloader = document.getElementById('preloader');

    body.classList.add("no-scroll");
    preloader.classList.remove('no-display');
}

function goToPost(post_id) {
    window.location.href = "/Home/Post/"+post_id;
}
//function postComment(event) {
//    if (event.key == "Enter") {
//        let form = document.getElementById("addComment");
//        form.submit();
//    }
//}

function setReplyTo(commentId, commentAuthorName, commentItem) {
    document.getElementById("replyTo").value = commentId;

    let comments = document.getElementsByClassName("comments-container")[0];
    for (var child of comments.children) {
        child.classList.remove("replyedComment");
    }

    commentItem.classList.add("replyedComment");

    const linkToComment = document.getElementById("replyToLink");
    linkToComment.innerHTML = commentAuthorName;
    linkToComment.href = "#comment-" + commentId;
    linkToComment.dataset.commentId = commentId;

    location.hash = "";
    location.hash = "#" + "add-comment-form";
}
function hightlightComment(a) {
    console.log(a);
}

function slideSidebar() {
    const contentWrapper = document.getElementById('contentWrapper');
    const sidebarWrapper = document.getElementById('sidebarWrapper');

    if (sidebarWrapper.classList.contains('shown')) {
        hideSidebar();
    } else {
        showSidebar();
    }
}

function showSidebar() {
    sidebarWrapper.classList.add('shown');
    contentWrapper.classList.add('slided');
}
function hideSidebar() {
    sidebarWrapper.classList.remove('shown');
    contentWrapper.classList.remove('slided');
}

var countLoaded = 6;

function loadMorePosts() {
    const spinner = document.getElementById('loadMorePostLoadingSpinner');
    spinner.classList.remove('collapsed');
    fetch('Home/GetPosts?skip=' + countLoaded + '&take=' + 2).then(
        function (responce) {
            spinner.classList.add('collapsed');

            if (responce.status !== 200) {
                console.error("cannot load more posts... status: " + responce.status);
                return;
            }

            responce.json().then(function (json) {
                const postTemplate = document.getElementById('post_item_template').innerHTML;
                const container = document.getElementsByClassName('other-posts')[0];
                const loadmoreBtn = document.getElementById('loadMoreBtn');
                console.log(json);
                if (json.length < 1) {
                    loadmoreBtn.classList.add('hidden');
                } else {
                    for (var i = 0; i < json.length; i++) {
                        json[i].description = json[i].description.substring(0, 150);
                        var rendered = Mustache.render(postTemplate, json[i]);
                        container.innerHTML += rendered;
                    }
                    countLoaded += json.length;
                }
            });
        }
    ).catch(function (error) {
        console.error("fetch error: " + error);
    });
}