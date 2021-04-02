export class petsModel{
    owner_id: number
    type: string 
    name: string
    age : number
    constructor()
    {
        this.owner_id=-1;
        this.type=''
        this.name=''
        this.age=0
    }
}
export class petsListModel  extends petsModel
{
    owner_name :string
    constructor()
    {
        super();
        this.owner_name = '';
    }
}