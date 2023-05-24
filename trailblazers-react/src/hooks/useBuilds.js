import { useState, useEffect } from "react";
import * as Services from "../services";

const useBuilds = () => {
  const [builds, setBuilds] = useState(null);

  const fetchBuilds = async () => {
    try {
      const { data: getBuildResponse } = await Services.BuildsService.list();
      setBuilds(getBuildResponse);
    } catch (error) {
      console.error("Error fetching build", error);
    }
  };

  useEffect(() => {
    fetchBuilds();
  }, []);

  return { builds, fetchBuilds };
};

export default useBuilds;
