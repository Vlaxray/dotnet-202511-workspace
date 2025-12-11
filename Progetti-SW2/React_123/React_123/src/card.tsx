interface CardProps {
    title : string
    body : string
    img : string
}


export default function Card({title , body , img} : CardProps){

    return(
        
        <div className="card" >
            <img className="img-fluid" src={img} alt="Card image cap" />
            <div className="card-body">
                <h5 className="card-title">{title}</h5>
                <p className="card-text">{body}</p>
                <a href="#" className="btn btn-primary">Go somewhere</a>
            </div>
        </div>
       
    );
}