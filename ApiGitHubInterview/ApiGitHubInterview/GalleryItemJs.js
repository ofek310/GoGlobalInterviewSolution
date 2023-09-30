console.log("okPage2");
var urlParams = new URLSearchParams(window.location.search);
var encodedData = urlParams.get("data");

// Decode the data and parse it back to an object
var jsonData = decodeURIComponent(encodedData);
var data = JSON.parse(jsonData);

let current_item = 0;
let pupup_send_email_model = document.getElementById("pupup_send_email_model");
let container_items = document.getElementById("container_items");
let out = "";
let counter = 0;
if (data!= null) {
    for (const item of data.items) {
        out += `
            <div class="col-md-3 d-flex">
                <div class="card">
                    <img class="img-thumbnail" src="${item.owner.avatar_url}">
                    <div class="card-body">
                        <h5 class="card-title">${item.full_name}</h5>
                    </div>
                    <div class="card-footer">
                        <button id="send_email_button_${counter} type="button" class="btn btn-primary send_email_button">Send Email</a>
                        <button id="bookmark_button_item_${counter}" type="button" class="btn btn-primary bookmark_button">Bookmark</a>
                    </div>
                 </div>
            </div>`;
        counter++;
    }
    container_items.innerHTML += out;
    var bookmark_buttons = document.querySelectorAll(".bookmark_button");
    bookmark_buttons.forEach((bookmark_button) => {
        bookmark_button.addEventListener("click", function () {
            let match = bookmark_button.id.match(/bookmark_button_item_(\d+)/);
            let current_item = parseInt(match[1], 10);
            postFetchBookmark(data.items[current_item]);
        })
    });
    var send_email_buttons = document.querySelectorAll(".send_email_button");
    send_email_buttons.forEach((send_email_button) => {
        send_email_button.addEventListener("click", function () {
            let match = send_email_button.id.match(/send_email_button_(\d+)/);
            current_item = parseInt(match[1], 10);
            pupup_send_email_model.classList.add("show");
            pupup_send_email_model.style.display = "block";
            pupup_send_email_model.setAttribute("aria-modal", "true");
            pupup_send_email_model.setAttribute("aria-hidden", "false");
        })
    });
}
document.getElementById("close_popup_button").addEventListener("click", function () {
    pupup_send_email_model.classList.remove("show");
    pupup_send_email_model.style.display = "none";
    pupup_send_email_model.setAttribute("aria-modal", "false");
    pupup_send_email_model.setAttribute("aria-hidden", "true");
})
document.getElementById("send_email_popup_button").addEventListener("click", function () {
    //asume that the user enter a good email
    let enter_email = document.getElementById("enter_email").value;
    var post_element = {
        item_repo: data.items[current_item],
        email: enter_email,
    };
    if (enter_email === "") {
        document.getElementById("message_error_to_user").innerText = "need to enter an email";
    } else {
        fetch("https://localhost:44397/SendEmail", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(post_element)
        })
            .then((response) => {
                if (!response.ok) {
                    return response.text().then(text => {
                        throw new Error(text); // Throw an error with the response body as the message.
                    });
                }
                //return response.json(); // Assuming the response contains JSON data
            }).then((result) => {
                document.getElementById("message_error_to_user").innerText = "the email send";
            })
            .catch((error) => {
                document.getElementById("message_error_to_user").innerText = error.message;
            })
    }
})
function postFetchBookmark(item) {
    fetch("https://localhost:44397/SaveInSession", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(item),
    })
        .then((response) => {
            if (!response.ok) {
                return response.text().then(text => {
                    throw new Error(text); // Throw an error with the response body as the message.
                });
            }
            return response.json(); // Assuming the response contains JSON data
        }).then((result) => { })
        .catch((error) => { })
}
document.getElementById("return_button").addEventListener("click", function () {
    var url = "Home.html";

    window.location.href = url;
})