import { useState, useEffect } from "react";
import * as Services from "../services";

const useDashboard = () => {
  const [trailblazers, setTrailblazers] = useState(null);
  const [elements, setElements] = useState(null);
  const [paths, setPaths] = useState(null);
  const [lightcones, setLightcones] = useState(null);
  const [relics, setRelics] = useState(null);
  const [ornaments, setOrnaments] = useState(null);

  const getDashboardData = async () => {
    try {
      const { data: getTrailblazerResponse } =
        await Services.TrailblazersService.list();
      setTrailblazers(getTrailblazerResponse);
    } catch (error) {
      console.error("Error fetching trailblazers", error);
    }

    try {
      const { data: getElementResponse } =
        await Services.ElementsService.list();
      setElements(getElementResponse);
    } catch (error) {
      console.error("Error fetching elements", error);
    }

    try {
      const { data: getPathResponse } = await Services.PathsService.list();
      setPaths(getPathResponse);
    } catch (error) {
      console.error("Error fetching paths", error);
    }

    try {
      const { data: getLightconeResponse } =
        await Services.LightconesService.list();
      setLightcones(getLightconeResponse);
    } catch (error) {
      console.error("Error fetching lightcones", error);
    }

    try {
      const { data: getRelicResponse } = await Services.RelicsService.list();
      setRelics(getRelicResponse);
    } catch (error) {
      console.error("Error fetching relics", error);
    }

    try {
      const { data: getOrnamentResponse } =
        await Services.OrnamentsService.list();
      setOrnaments(getOrnamentResponse);
    } catch (error) {
      console.error("Error fetching ornaments", error);
    }
  };

  useEffect(() => {
    getDashboardData();
  }, []);

  return {
    trailblazers,
    elements,
    paths,
    lightcones,
    relics,
    ornaments,
    getDashboardData,
  };
};

export default useDashboard;
