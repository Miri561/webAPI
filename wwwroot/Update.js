

const firstName = document.querySelector("#firstName")
const lastName= document.querySelector("#lastName")
        //id: document.querySelector("#id").value,
const useremail= document.querySelector("#useremail")
const password = document.querySelector("#password")
data = JSON.parse(sessionStorage.getItem("currentUser"))
firstName.value = data.firstName
lastName.value = data.lastName
useremail.value = data.useremail
password.value= data.password

const update = async () => {
    const userData3 = {
        firstName: document.querySelector("#firstName").value,
        lastName: document.querySelector("#lastName").value,
        //id: document.querySelector("#id").value,
        useremail: document.querySelector("#useremail").value,
        password: document.querySelector("#password").value,
        id: data.id
    };
    
    const responsePut = await fetch("api/Users/"+data.id, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(userData3)
    });
   
    if (!responsePut.ok) {
        alert('http error  put')
    }
    else
        alert("grate update!")
    const dataPost = await responsePut.json;


}