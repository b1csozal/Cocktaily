import axios from "axios";

const BASE_URL = "https://j79j8cjx-7136.euw.devtunnels.ms/";

const apiClient = axios.create({
  baseURL: BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

export default apiClient;