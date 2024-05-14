const bookList = [
    {
        id: 0,
        title: "Harry Potter és a bölcsek ostora",
        author: "J.K. Rownling",
        rl_date: "1999",
        price: 3000,
        quant_avail: 3,
    },
    {
        id: 1,
        title: "Harry Potter és a Cigók panorámája",
        author: "J.K. Rownling",
        rl_date: "2000",
        price: 3500,
        quant_avail: 5,
    },
    {
        id: 2,
        title: "Harry Potter és a félvér niga",
        author: "J.K. Rownling",
        rl_date: "2002",
        price: 5000,
        quant_avail: 2,
    },
    {
        id: 3,
        title: "Harry Potter és a nigák erekjéi",
        author: "J.K. Rownling",
        rl_date: "2003",
        price: 5000,
        quant_avail: 1,
    },
    {
        id: 4,
        title: "Harry Potter és a tűznigák",
        author: "J.K. Rownling",
        rl_date: "2001",
        price: 4000,
        quant_avail: 5,
    },
    {
        id: 5,
        title: "Harry Potter és a gyapotföldi fogoly",
        author: "J.K. Rownling",
        rl_date: "2000",
        price: 4500,
        quant_avail: 3,
    },
];
console.table(bookList);

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

    //const table = document.querySelector("#std_table");

    /*for(i = 0; i < bookList.length; i++){
        const row = document.createElement("tr");
        row.innerHTML = "ASD";
        document.body.appendChild(row);
        //console.log("ITEM: " + bookList[i].title);
    }*/


    // creates a <table> element and a <tbody> element
    const table = document.createElement("table");
    const tableBody = document.createElement("tbody");

    // creating all cells
    for (let i = 0; i < bookList.length; i++) {
        // creates a table row
        const row = document.createElement("tr");

        const data1 = document.createElement("td");
        data1.innerHTML = bookList[i].id;
        row.appendChild(data1);
        const data2 = document.createElement("td");
        data2.innerHTML = bookList[i].title;
        row.appendChild(data2);
        const data3 = document.createElement("td");
        data3.innerHTML = bookList[i].author;
        row.appendChild(data3);
        const data4 = document.createElement("td");
        data4.innerHTML = bookList[i].rl_date;
        row.appendChild(data4);
        const data5 = document.createElement("td");
        data5.innerHTML = bookList[i].price;
        row.appendChild(data5);
        const data6 = document.createElement("td");
        data6.innerHTML = bookList[i].quant_avail;
        row.appendChild(data6);

        tableBody.appendChild(row);
    }
    table.appendChild(tableBody);

    std_books.appendChild(table);
}


function LogOut() {
    loginClass.style = "display: block;";
    admin.style = "display: none;";
    student.style = "display: none;";
}