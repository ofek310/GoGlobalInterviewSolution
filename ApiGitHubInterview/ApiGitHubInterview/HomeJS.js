function waiting() {
    document.getElementById("message_error").innerHTML = "";
    document.getElementById("search_button").disabled = true;
    document.getElementById("waiting").innerHTML = `<div class="d-flex justify-content-center">
<strong>Loading...</strong>
  <div class="spinner-border custom-spinner" role="status">
    <span class="sr-only">Loading...</span>
  </div>
</div>`;
}
console.log("here");
document.getElementById("search_button").addEventListener("click", function () {
    let user_search_keyword = document.getElementById("user_keyword_text").value;
    if (user_search_keyword === "") {
        document.getElementById("message_error").innerHTML = "you must enter something";
    } else {
        console.log("kkk");
        waiting();
        fetch("https://localhost:44397/api/GitHubRepository/" + user_search_keyword)
            .then(response => {
                if (!response.ok) {
                    return response.text().then(text => {
                        throw new Error(text); // Throw an error with the response body as the message.
                    });
                }
                return response.json(); // Assuming the response contains JSON data
            })
            .then((result) => {
                var jsonData = JSON.stringify(result);
                var encodedData = encodeURIComponent(jsonData);
                var url = "GalleryItems.html?data=" + encodedData;

                window.location.href = url;
            })
            .catch((error) => {
                document.getElementById("waiting").innerHTML = "";
                document.getElementById("search_button").disabled = false;
                document.getElementById("message_error").innerHTML = error.message;
            })
    }
})