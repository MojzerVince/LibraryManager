const form = document.querySelector("#login_form");
let loginClass = document.querySelector(".login");
let admin = document.querySelector(".ad_logged");
let student = document.querySelector(".std_logged");

form.addEventListener("submit", function(event){
    event.preventDefault();
    loginClass.style = "display: none;";
    console.log("LOGGED IN");

    let formData = new FormData(form);
    if(formData.get("type") == 'admin'){
        admin.style = "display: grid;";
    }
    else{
        student.style = "display: grid;";
    }
    //console.log(formData.getAll("type"));
})