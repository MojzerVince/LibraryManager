const form = document.querySelector("#login_form");
let loginClass = document.querySelector(".login");
let admin = document.querySelector(".ad_logged");
let student = document.querySelector(".std_logged");

form.addEventListener("submit", function (event) {


    let formData = new FormData(form);
    if (formData.get("password") != "") {
        event.preventDefault();
        loginClass.style = "display: none;";
        console.log("LOGGED IN");

        if (formData.get("type") == 'admin') {
            admin.style = "display: grid;";

            let ad_user = document.querySelector("#ad_user");
            ad_user.innerHTML = formData.get("username");

            let ad_content = document.querySelector(".ad_content");
            ad_content.style = "display: block;";
        }
        else {
            student.style = "display: grid;";
        }
    }
    else alert("Please enter password!");
})

let ad_books = document.querySelector("#ad_books");
let ad_students = document.querySelector("#ad_students");
function Books() {
    ad_books.style = "display: block;";
    ad_students.style = "display: none;";
}
function Students() {
    ad_books.style = "display: none;";
    ad_students.style = "display: block;";
}