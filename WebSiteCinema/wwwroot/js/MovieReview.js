var connection = new WebSocketManager.Connection("wss://localhost:44301/MovieReview"); 
connection.enableLogging = true;

connection.connectionMethods.onConnected = () => {

}

connection.connectionMethods.onDisconnected = () => {

}

connection.clientMethods["pingMessage"] = (message,user_login, review_date) => {
    $('#reviewsContainer').append
    (
        "<div class='review'>" +
            "<div class='review-header'> " +
                "<span class='review-user'>"+ user_login +"</span> " +
                "<span class='review-date'>"+parseDate(review_date)+"</span> " +
            "</div> " +
            "<div class='review-text format-review'>"+message+"</div> " +
        "</div>"
    )
    alert(message)
}
connection.start();

function openReviewSection(){
    $("#reviewSection").toggle()
}
function sendReview(){
    if($("#review").val()!=null) {
        let message = $("#review").val();
        let login = $("#login").text();
        let film_id =$("#filmIdContainer").val()
        connection.invoke("SendMessage",message,login,film_id);
        $("#review").val("");
        openReviewSection();
    }
    
}
function parseDate(dateString){
    let arr = dateString.split('T');
    let date = arr[0];
    let timeArr = String(arr[1]).split(":");
    let res = date + " " + timeArr[0]+":"+timeArr[1];
    return res;
}