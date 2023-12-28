function zatvori()
{
    document.getElementById("my-dialog-wrapper").style.display = "none"
}
function dialogSuccess(p)
{
    document.body.innerHTML += `  <div id="my-dialog-wrapper">
    <div class="my-dialog">
        <div class="my-dialog-header">
            <div class="header-icon">
                <img src="/assets/success.png">
                <span>Success</span>
            </div>
        </div>
        <div id="my-dialog-body">
            ${p}
        </div>
        <div class="my-dialog-footer">
            <div class="dugme" onclick="zatvori()">
                Continue
            </div>
        </div>
    </div>
</div>`

document.querySelector("style").innerHTML += ` #my-dialog-wrapper{
    background-color: rgba(0, 0, 0, 20%);
    position: fixed;
    top:0;
    left: 0;
    right: 0;
    bottom: 0;
    backdrop-filter: blur(5px);
    display: none;;
}
.my-dialog{
    background-color: white;
    width: 300px;
    margin-left: auto;
    margin-right: auto;
    margin-top: 100px;
    box-shadow: 4px 10px 26px 0px rgba(0,0,0,0.75);
}

.my-dialog-header{
    background-color: rgb(140,194,73);
    color: white;
    text-align: center;
    padding: 30px;
}
.my-dialog-header span{
    display: block;
}
#my-dialog-body{
    padding: 20px;
    text-align: center;
}

.dugme{
    background-color: rgb(140,194,73);
    color: white;
    width: fit-content;
    padding: 10px 30px;
    border-radius: 20px;
    margin-left: auto;
    margin-right: auto;
    cursor: pointer;
}

.my-dialog-footer{
    padding: 10px;
}`

   // document.getElementById("my-dialog-body").innerHTML = p;
    document.getElementById("my-dialog-wrapper").style.display = "block"
}
