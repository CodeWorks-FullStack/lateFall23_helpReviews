import {api} from './AxiosService.js'
import {logger} from '../utils/Logger.js'
import {Report}from '../models/Report.js'
import {AppState} from '../AppState.js'


class ReportsService{
  async getRestaurantReports(restaurantId){
    AppState.reports = []
    const response = await api.get(`api/restaurants/${restaurantId}/reports`)
    logger.log('📜', response.data)
    AppState.reports = response.data.map(report => new Report(report))
  }

  async createReport(reportData){
    const response = await api.post('api/reports', reportData)
    logger.log('📜✨', response.data)
    // REVIEW only push in if on the appropriate page
    if(AppState.activeRestaurant?.id == reportData.restaurantId){
      AppState.reports.push(new Report(response.data))
    }
  }
}

export const reportsService = new ReportsService();
