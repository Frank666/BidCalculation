import axios from "axios";
import { Fees } from "../types/Fees";

//Get values from VITE env
const API_URL = import.meta.env.VITE_API_URL;
const BID_ENDPOINT = import.meta.env.VITE_API_BID_ENDPOINT;
const GET_BID = import.meta.env.VITE_API_GET_BID;

const apiClient = axios.create({
  baseURL: API_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

export const BidCalculationService = async (price: number, type: string) => {
  try {
    const response = (await apiClient.get)<Fees>(
      `${API_URL}${BID_ENDPOINT}${GET_BID}`,
      {
        params: {
          price,
          type,
        },
      }
    );
    return (await response).data;
  } catch (error) {
    console.error("Error fetching bid:", error);
    throw error;
  }
};
