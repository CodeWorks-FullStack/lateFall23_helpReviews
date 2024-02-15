import { Profile } from "./Account.js"



export class Report{
  constructor(data){
    this.id = data.id
    this.title = data.title
    this.body = data.body
    this.creatorId = data.creatorId
    this.creator = new Profile(data.creator)
    this.restaurantId = data.restaurantId
  }
}
