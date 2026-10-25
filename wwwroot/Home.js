

const SignIn = async () => {
    const userData = {
        firstName: document.querySelector("#firstName").value,
        lastName: document.querySelector("#lastName").value,
        //id: document.querySelector("#id").value,
        useremail: document.querySelector("#useremail").value,
        password: document.querySelector("#password").value,

    };

    const responsePost = await fetch('api/Users', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userData)
    });
    if (!responsePost.ok) {
       alert('http error ')
    }
    else
        alert("grate tou inside!")
    const dataPost = await responsePost.json();

    
}

const LogIn = async () => {
    const userData2 = {
        firstName: "k",
        lastName: "m",
        useremail: document.querySelector("#email2").value,
        password: document.querySelector("#password2").value,
    };
    const responsePostl = await fetch('api/Users/Login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userData2)
    })
    if (!responsePostl.ok) {
        alert('not found')
    }
    else {
        
        const dataPost = await responsePostl.json();
        sessionStorage.setItem("currentUser", JSON.stringify(dataPost));
        alert("you found")
    }
        
   

}

