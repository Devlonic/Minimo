// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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

var sidebarDefaultOffset;
window.addEventListener('scroll', (event) => {
    //const sidebar = document.getElementById('sidebarWrapper');
    //const header = document.getElementById('header');
    //if (sidebarDefaultOffset === undefined) {
    //    sidebarDefaultOffset = sidebar.offsetTop;
    //}

    //const y = sidebar.getBoundingClientRect().y;
    //console.log();
    //if (y - header.getBoundingClientRect().height <= 0) {
    //    sidebar.style.top = header.getBoundingClientRect().height + sidebarDefaultOffset + y * -1 + "px";
    //}
});

window.addEventListener('scroll', (event) => {
    const sidebar = document.getElementById('sidebarWrapper');
});
