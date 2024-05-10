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

            let std_user = document.querySelector("#std_user");
            std_user.innerHTML = formData.get("username");

            let std_content = document.querySelector(".std_content");
            std_content.style = "display: block;";
        }
    }
    else alert("Please enter password!");
})

let ad_books = document.querySelector("#ad_books");
let ad_students = document.querySelector("#ad_students");
function Books_admin() {
    ad_books.style = "display: block;";
    ad_students.style = "display: none;";
}
function Students() {
    ad_books.style = "display: none;";
    ad_students.style = "display: block;";
}

function Books_std() {
    let std_books = document.querySelector("#std_books");
    std_books.style = "display: block;";
}